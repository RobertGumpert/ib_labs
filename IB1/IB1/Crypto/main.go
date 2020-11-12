package main

import (

	"crypto/cipher"
	"crypto/des"
	"fmt"
	"io/ioutil"
	"os"
	"strings"
)

var (
	k   = "ib_lab_1"
	key = []byte(k)
	iv  = []byte(k)
)

// os.Args
//
// 		запись из временного файла, шифрование и запись в основной файл:
// 		-w tempfile userfile
//             -w C:\\Labs\\ib\\IB1\\IB1\\Data\\user.json C:\\Labs\\ib\\IB1\\IB1\\Data\\temp.json
// 		чтение из основного файла, расшифрование и запись во временный файл:
//      -r tempfile userfile
// 			   -r C:\\Labs\\ib\\IB1\\IB1\\Data\\user.json C:\\Labs\\ib\\IB1\\IB1\\Data\\temp.json
//
func main() {
	var e = "error:"
	defer func() {
		if rec := recover(); rec != nil {
			fmt.Println(e, "recovery ", rec)
			return
		}
	}()
	args := os.Args
	if args[1] != "-r" && args[1] != "-w" {
		fmt.Println(e)
		return
	}
	if strings.TrimSpace(args[2]) != "" && strings.TrimSpace(args[3]) != "" {
		args[2] = strings.ReplaceAll(args[2], "\\", "/")
		args[3] = strings.ReplaceAll(args[3], "\\", "/")
		args[2] = strings.ReplaceAll(args[2], "//", "/")
		args[3] = strings.ReplaceAll(args[3], "//", "/")
	} else {
		fmt.Println(e)
		return
	}
	if args[1] == "-r" {
		err := ReadDecryptContent(args[2], args[3])
		if err != nil {
			fmt.Println(e, err)
			return
		}
		fmt.Println("ok")
		return
	}
	if args[1] == "-w" {
		err := WriteEncryptContent(args[2], args[3])
		if err != nil {
			fmt.Println(e, err)
			return
		}
		fmt.Println("ok")
		return
	}
	fmt.Println(e)
	return
}

func WriteEncryptContent(userFile, tempFile string) error {
	tempFileContent, err := onlyReadFile(tempFile)
	if err != nil {
		return err
	}
	crypted, err := desEncrypt(tempFileContent)
	if err != nil {
		return err
	}
	err = rewriteFile(userFile, crypted)
	if err != nil {
		return err
	}
	return nil
}

func ReadDecryptContent(userFile, tempFile string) error {
	crypted, err := onlyReadFile(userFile)
	if err != nil {
		return err
	}
	decrypted, err := desDecrypt(crypted)
	if err != nil {
		return err
	}
	err = writeFile(tempFile, decrypted)
	if err != nil {
		return err
	}
	return nil
}

func onlyReadFile(fileName string) ([]byte, error) {
	data, err := ioutil.ReadFile(fileName)
	if err != nil {
		return nil, err
	}
	return data, nil
}

func writeFile(fileName string, content []byte) error {
	err := ioutil.WriteFile(fileName, content, 0644)
	if err != nil {
		return err
	}
	return nil
}

func rewriteFile(rewriteFileName string, content []byte) error {
	err := os.Remove(rewriteFileName)
	if err != nil {
		return err
	}
	err = writeFile(rewriteFileName, content)
	if err != nil {
		return err
	}
	return nil
}


func desEncrypt(plainText []byte) ([]byte, error){
	block, err := des.NewCipher(key)
	if err != nil {
		return nil, err
	}
	ciphertext := make([]byte, des.BlockSize+len(plainText))
	stream := cipher.NewOFB(block, iv)
	stream.XORKeyStream(ciphertext[des.BlockSize:], plainText)
	return ciphertext, nil
}

func desDecrypt(cipherText []byte) ([]byte, error) {
	block, err := des.NewCipher(key)
	if err != nil {
		return nil, err
	}
	plaintext := make([]byte, len(cipherText))
	stream := cipher.NewOFB(block, iv)
	stream.XORKeyStream(plaintext, cipherText[des.BlockSize:])
	return plaintext, nil
}