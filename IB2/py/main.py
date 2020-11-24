def circle_left_rotate(num, shift):
    return ((num << shift) | (num >> (32 - shift))) & 0xffffffff


def get_chunks(string, len_chunk):
    start_index_chunk = 0
    end_index_chunk = 0
    count_chunks = int(len(string) / len_chunk)
    chunks = list()
    #
    for index in range(0, count_chunks, 1):
        end_index_chunk = start_index_chunk + len_chunk
        chunk = string[start_index_chunk: end_index_chunk]
        chunks.append(chunk)
        start_index_chunk = end_index_chunk
    return chunks


def init_sha(message):
    original_bits = ""
    for index in range(len(message)):
        original_bits += '{0:08b}'.format(ord(message[index]))
    add_bits = original_bits + "1"
    while len(add_bits) % 512 != 448:
        add_bits += "0"
    add_bits += '{0:064b}'.format(len(original_bits))
    blocks = get_chunks(add_bits, 512)
    return blocks


def hash_sum(blocks):
    #
    buffer_a = 0x67452301
    buffer_b = 0xEFCDAB89
    buffer_c = 0x98BADCFE
    buffer_d = 0x10325476
    buffer_e = 0xC3D2E1F0
    #
    for block in blocks:
        #
        bit_words = get_chunks(block, 32)
        w = [0] * 80
        #
        for t in range(0, 16):
            w[t] = int(bit_words[t], 2)
        for t in range(16, 80):
            xor = (w[t - 3] ^ w[t - 8] ^ w[t - 14] ^ w[t - 16])
            left_shift = circle_left_rotate(xor, 1)
            w[t] = left_shift
        #
        temp_buffer_a = buffer_a
        temp_buffer_b = buffer_b
        temp_buffer_c = buffer_c
        temp_buffer_d = buffer_d
        temp_buffer_e = buffer_e
        #
        for t in range(0, 80):
            #              | (x & y) | (!x & z),            t = [0,19]
            # f_t(x,y,z) = | x xor y xor z,                 t = [20,39]
            #              | (x & y) | (x & z) | (y & z),   t = [40,59]
            #              | x xor y xor z,                 t = [60,79]
            result_function = 0
            k = 0
            #
            if 0 <= t <= 19:
                # (x & y) | (!x & z)
                result_function = (temp_buffer_b & temp_buffer_c) | ((~temp_buffer_b) & temp_buffer_d)
                k = 0x5A827999
            if 20 <= t <= 39:
                # x xor y xor z
                result_function = temp_buffer_b ^ temp_buffer_c ^ temp_buffer_d
                k = 0x6ED9EBA1
            if 40 <= t <= 59:
                # (x & y) | (x & z) | (y & z)
                result_function = (temp_buffer_b & temp_buffer_c) | (temp_buffer_b & temp_buffer_d) | (
                        temp_buffer_c & temp_buffer_d)
                k = 0x8F1BBCDC
            if 60 <= t <= 79:
                # x xor y xor z
                result_function = temp_buffer_b ^ temp_buffer_c ^ temp_buffer_d
                k = 0xCA62C1D6
            #
            # tmp = (a <<< 5) + f_t(b,c,d) + e + w_t + k_t
            temp = circle_left_rotate(temp_buffer_a, 5) + result_function + temp_buffer_e + k + w[t] & 0xffffffff
            # e <- d
            temp_buffer_e = temp_buffer_d
            # d <- c
            temp_buffer_d = temp_buffer_c
            # c <- (b <<< 30)
            temp_buffer_c = circle_left_rotate(temp_buffer_b, 30)
            # b <- a
            temp_buffer_b = temp_buffer_a
            # a <- tmp
            temp_buffer_a = temp
            #
        buffer_a = buffer_a + temp_buffer_a & 0xffffffff
        buffer_b = buffer_b + temp_buffer_b & 0xffffffff
        buffer_c = buffer_c + temp_buffer_c & 0xffffffff
        buffer_d = buffer_d + temp_buffer_d & 0xffffffff
        buffer_e = buffer_e + temp_buffer_e & 0xffffffff
    #
    return '%08x%08x%08x%08x%08x' % (buffer_a, buffer_b, buffer_c, buffer_d, buffer_e)


def main():
    blocks = init_sha("Hello world")
    digest = hash_sum(blocks)
    print(digest)


if __name__ == '__main__':
    main()
