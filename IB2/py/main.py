import base64
import binascii
import codecs
import json
import sys

json_report = dict()


# Циклический сдвиг отличается от линейного тем,
# биты с одного конца перемещаются на место место битов на другом конце,
# то есть движутся по кольцу.
#
# Пример:
#   сдвиг влево на 1:
#       input:  0 1 1 1
#       output: 1 1 1 0
#
#   сдвиг влево на 2:
#       input:  0 1 1 1
#       output: 1 1 0 1
#
#   сдвиг вправо на 1:
#       input:  0 1 1 1
#       output: 1 0 1 1
#
#   сдвиг вправо на 2:
#       input:  0 1 1 1
#       output: 1 1 0 1
#
#   выполнение кода фунции над числом 53 со сдвигом влево на 30:
#       Число              =  00000000000000000000000000110101
#       Сдвиг влево        =  110101000000000000000000000000000000
#       Сдвиг вправо       =  00000000000000000000000000001101
#       Логическое или     =  110101000000000000000000000000001101
#       Результат с маской =  01000000000000000000000000001101
#
#   выполнение кода фунции над числом 53 со сдвигом влево на 5:
#       Число              =  00000000000000000000000000110101
#       Сдвиг влево        =  00000000000000000000011010100000
#       Сдвиг вправо       =  00000000000000000000000000000000
#       Логическое или     =  00000000000000000000011010100000
#       Результат с маской =  00000000000000000000011010100000
#
def circle_left_shift(num, shift, show):
    if show is True:
        print('Число              = ', '{0:032b}'.format(num))
        rotate_left = (num << shift)
        print('Сдвиг влево        = ', '{0:032b}'.format(rotate_left))
        rotate_right = (num >> (32 - shift))
        print('Сдвиг вправо       = ', '{0:032b}'.format(rotate_right))
        or_rotate = rotate_left | rotate_right
        print('Логическое или     = ', '{0:032b}'.format(or_rotate))
        mask_32_bits = or_rotate & 0xffffffff
        print('Результат с маской = ', '{0:032b}'.format(mask_32_bits))
    return ((num << shift) | (num >> (32 - shift))) & 0xffffffff


# Функция выполняет выделение чанков (битовых слов длиной n)
# из исходной строки (блока) длиной 512 элементов (бит).
#
# Пример: веделить в string, битовые слова длиной len_chunk = 32
#   input: "01001000011001010110110001101100
#           01101111001000000111011101101111
#           01110010011011000110010010000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000000000000
#           00000000000000000000000001011000"
#
#   output:
#           [0]  = "01001000011001010110110001101100",
#           [1]  = "01110010011011000110010010000000",
#           ...
#           [15] = "00000000000000000000000001011000",
#
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


# Исходное сообщение разбивается на блоки по 512 бит в каждом.
# Последний блок дополняется до длины, кратной 512 бит.
# Сначала добавляется 1 а потом нули, чтобы длина блока стала равной (512 - 64 = 448) бит.
# В оставшиеся 64 бита записывается длина исходного сообщения в битах.
# Если последний блок имеет длину более 448, но менее 512 бит, дополнение выполняется следующим образом:
# сначала добавляется 1, затем нули вплоть до конца 512-битного блока; после этого создается ещё один 512-битный блок,
# который заполняется вплоть до 448 бит нулями,
# после чего в оставшиеся 64 бита записывается длина исходного сообщения в битах.
# Дополнение последнего блока осуществляется всегда, даже если сообщение уже имеет нужную длину.
def init_sha(message):
    # строка исходного сообщения
    original_bits = ""
    for index in range(len(message)):
        #
        # Для каждого символа строки в создаём
        # двоичное представление длинной 8 бит,
        #
        # Примечание: '{0:08b}' <= python 2.6
        original_bits += '{0:08b}'.format(ord(message[index]))
    #
    # Добавляем один бит равный 1
    #
    add_bits = original_bits + "1"
    #
    # Доблавляем биты равные 0,
    # до тех пор пока остаток от деления
    # длины строки на 512 не станет равной 448
    #
    while len(add_bits) % 512 != 448:
        add_bits += "0"
    #
    # К текущему представлению строки добавим
    # ещё 64 бита, содержащие длину исходного сообщения.
    #
    # Примечание: '{0:064b}' <= python 2.6
    add_bits += '{0:064b}'.format(len(original_bits))
    #
    # Выделим блоки по 512 бит каждый в массив.
    #
    blocks = get_chunks(add_bits, 512)
    return blocks


def hash_sum(blocks, create_report):
    #
    # Инициализируем пять 32 битных буфера,
    # с "константными" значениями (на этапе инициализации),
    # которые будут хранить результат хэш-алгоритма и
    # будут представлять из себя дайжест сообщения длиной 160 бит.
    #
    buffer_a = 0x67452301
    buffer_b = 0xEFCDAB89
    buffer_c = 0x98BADCFE
    buffer_d = 0x10325476
    buffer_e = 0xC3D2E1F0
    #
    # Для каждого 512 битового блока,
    # выполняем преобразование буфферов.
    #
    json_list_blocks = list()
    for block in blocks:
        #
        # Для каждого 512 битового блока,
        # выделим шестнадцать 32 битных слова Mi.
        #
        bit_words = get_chunks(block, 32)
        #
        # Шестнадцать 32 битных слова, преобразуем
        # в восемьдесят 32 битных слова Wi.
        #
        w = [0] * 80
        #
        # Преобразование из Mi в Wi:
        # Для раундов алгоритма [0;16],
        # преобразование выполняется по правилу:
        # Wi = Mi,
        # где i - раунд алгоритма.
        #
        for round_index in range(0, 16):
            w[round_index] = int(bit_words[round_index], 2)
        #
        # Преобразование из Mi в Wi:
        # Для раундов алгоритма [16;80],
        # преобразование выполняется по правилу:
        # Wi = (Wi-3 xor Wi-8 xor Wi-14 xor Wi-16) <<< 1,
        # где i - раунд алгоритма.
        #
        for round_index in range(16, 80):
            xor = (w[round_index - 3] ^ w[round_index - 8] ^ w[round_index - 14] ^ w[round_index - 16])
            left_shift = circle_left_shift(xor, 1, False)
            w[round_index] = left_shift
        #
        # Копируем текущее значение буферов.
        #
        temp_buffer_a = buffer_a
        temp_buffer_b = buffer_b
        temp_buffer_c = buffer_c
        temp_buffer_d = buffer_d
        temp_buffer_e = buffer_e
        #
        json_block = dict()
        if create_report is True:
            json_block["block_value"] = block
            json_block["w_i"] = ['{0:032b}'.format(int(x)) for x in w.copy()]
            json_block["temp_buffer"] = [{"a": '{0:032b}'.format(temp_buffer_a)},
                                         {"b": '{0:032b}'.format(temp_buffer_b)},
                                         {"c": '{0:032b}'.format(temp_buffer_c)},
                                         {"d": '{0:032b}'.format(temp_buffer_d)},
                                         {"e": '{0:032b}'.format(temp_buffer_e)}]
        #
        # Главный цикл алгоритма с 80 раундами
        #
        json_list_rounds = list()
        for round_index in range(0, 80):
            #
            # Для каждого раунда алгоритма, выделяется нелинейная функция,
            # преобразования скопированных значений буферов F(x,y,z), где
            # x - буффер B, y - буффер C, z - буффер D, а также константа K.
            #
            #                       > (x & y) | (!x & z),            round_index = [0,19]
            # F_round_index(x,y,z) => x xor y xor z,                 round_index = [20,39]
            #                       > (x & y) | (x & z) | (y & z),   round_index = [40,59]
            #                       > x xor y xor z,                 round_index = [60,79]
            result_function = 0
            k = 0
            #
            if 0 <= round_index <= 19:
                #
                # (x & y) | (!x & z)
                #
                result_function = (temp_buffer_b & temp_buffer_c) | ((~temp_buffer_b) & temp_buffer_d)
                k = 0x5A827999
            if 20 <= round_index <= 39:
                #
                # x xor y xor z
                #
                result_function = temp_buffer_b ^ temp_buffer_c ^ temp_buffer_d
                k = 0x6ED9EBA1
            if 40 <= round_index <= 59:
                #
                # (x & y) | (x & z) | (y & z)
                #
                result_function = (temp_buffer_b & temp_buffer_c) | (temp_buffer_b & temp_buffer_d) | (
                        temp_buffer_c & temp_buffer_d)
                k = 0x8F1BBCDC
            if 60 <= round_index <= 79:
                #
                # x xor y xor z
                #
                result_function = temp_buffer_b ^ temp_buffer_c ^ temp_buffer_d
                k = 0xCA62C1D6
            #
            # После выполнения преобразования с помощью нелинейной ф-ии,
            # определения константы К, выполняется перезапись буфферов по правилам:
            #
            #   tmp = (a <<< 5) + f_t(b,c,d) + e + w_t + k_t
            #   e <- d
            #   d <- c
            #   c <- (b <<< 30)
            #   b <- a
            #   a <- tmp.
            #
            #
            # tmp = (a <<< 5) + f_t(b,c,d) + e + w_t + k_t
            #
            temp = circle_left_shift(temp_buffer_a, 5, False) + result_function + temp_buffer_e + k + w[
                round_index] & 0xffffffff
            #
            # e <- d
            #
            temp_buffer_e = temp_buffer_d
            #
            # d <- c
            #
            temp_buffer_d = temp_buffer_c
            #
            # c <- (b <<< 30)
            #
            temp_buffer_c = circle_left_shift(temp_buffer_b, 30, False)
            #
            # b <- a
            #
            temp_buffer_b = temp_buffer_a
            #
            # a <- tmp
            #
            temp_buffer_a = temp
            #
            json_round = dict()
            if create_report is True:
                json_round["round_index"] = round_index
                json_round["f"] = '{0:032b}'.format(result_function)
                json_round["k"] = '{0:032b}'.format(k)
                json_round["change_temp_buffer"] = [{"a": '{0:032b}'.format(temp_buffer_a)},
                                                    {"b": '{0:032b}'.format(temp_buffer_b)},
                                                    {"c": '{0:032b}'.format(temp_buffer_c)},
                                                    {"d": '{0:032b}'.format(temp_buffer_d)},
                                                    {"e": '{0:032b}'.format(temp_buffer_e)}]
                json_list_rounds.append(json_round)

        #
        # После преобразования временных буффером
        # в цикле по каждому 512 блоку, выходные буфферы,
        # складываются с временными и преобразуются по маске
        # до 32 бит.
        #
        buffer_a = buffer_a + temp_buffer_a & 0xffffffff
        buffer_b = buffer_b + temp_buffer_b & 0xffffffff
        buffer_c = buffer_c + temp_buffer_c & 0xffffffff
        buffer_d = buffer_d + temp_buffer_d & 0xffffffff
        buffer_e = buffer_e + temp_buffer_e & 0xffffffff
        #
        if create_report is True:
            json_block["rounds"] = json_list_rounds
            json_block["origin_buffer"] = [{"a": '{0:032b}'.format(buffer_a)},
                                           {"b": '{0:032b}'.format(buffer_b)},
                                           {"c": '{0:032b}'.format(buffer_c)},
                                           {"d": '{0:032b}'.format(buffer_d)},
                                           {"e": '{0:032b}'.format(buffer_e)}]
            json_list_blocks.append(json_block)
    #
    if create_report is True:
        json_report["blocks"] = json_list_blocks
    #
    # Дайжест сообщения.
    #
    return '%08x%08x%08x%08x%08x' % (buffer_a, buffer_b, buffer_c, buffer_d, buffer_e)


# os.args
#   report -t file
#   report -f file
#
def main():
    args = sys.argv
    create_report = False
    file_name = args[3]
    file_content = ""
    if args[2] == '-t':
        create_report = True
    with open(file_name, "rb") as f:
        byte = f.read()
        hex_file_represent = byte.hex()
        file_content = ''.join(
            [chr(int(''.join(c), 16)) for c in zip(hex_file_represent[0::2], hex_file_represent[1::2])])
        #
    blocks = init_sha(file_content)
    hash_file_content = hash_sum(blocks, create_report)
    print(hash_file_content)
    if create_report is True:
        with open('result.json', 'w') as f:
            json.dump(json_report, f)


if __name__ == '__main__':
    main()
