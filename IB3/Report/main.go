package main

import (
	"./app/httpserver"
	"./app/neworder"
	"./mailer"
	"log"
	"os"
	"path/filepath"
	"runtime"
)

func main() {
	port := ":80"
	root := getRoot()
	configuredApp(root)
	httpserver.Start(root, port)
}

func getRoot() string {
	_, file, _, _ := runtime.Caller(0)
	root := filepath.Dir(file)
	return root
}

func configuredApp(root string) {
	storage := new(mailer.PostStorage)
	order := new(neworder.EmailAgent)
	err := storage.SettingsFromConfig(root + "/configs/storage.json")
	if err != nil {
		log.Println(err.Error())
		os.Exit(0)
	}
	err = order.SettingFromConfig(root+"/configs/new_order.json", root, storage)
	if err != nil {
		log.Println(err.Error())
		os.Exit(0)
	}
	httpserver.AddMailerStorage(storage)
	neworder.AddEmailAgent(order)
}
