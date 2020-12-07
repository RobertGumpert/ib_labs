package main

import (
	"strconv"
	"strings"
)

type Handler func(file *File, search *Search, directory *Directory) bool
type MoreHandlers map[string]Handler

type File struct {
	Size int64
	Name string
	Path string
	Ext  string
}

type Directory struct {
	Path           string
	IndexNextChild int64
	ListChild      []*Directory
	MapFiles       map[string]*File
	PointParent    *Directory
	Check          bool
}

type Search struct {
	Root       string
	FindBy     map[string]string
	FileSystem *Directory
	FoundFiles map[string]*File
	FoundDirs  map[string]*Directory
	IsAll      bool
	FindDir    bool
	FindFile   bool
}

func byName(file *File, search *Search, directory *Directory) bool {
	var (
		s      = search.FindBy["--name"]
		equals = func(s1, s2 string) bool {
			if s1 == s2 {
				return true
			}
			return false
		}
	)
	if search.FindDir {
		slice := strings.Split(directory.Path, "/")
		name := slice[len(slice)-2]
		if name == s {
			return true
		}
		return false
	} else {
		if strings.Contains(s, ".") {
			slice := strings.Split(s, ".")
			if equals(slice[0], file.Name) && equals("."+slice[1], file.Ext) {
				return true
			}
			return false
		} else {
			if equals(s, file.Name) {
				return true
			}
			return false
		}
	}
}

func byContains(file *File, search *Search, directory *Directory) bool {
	if strings.Contains(file.Name, search.FindBy["--cont"]) {
		return true
	}
	return false
}

func bySize(file *File, search *Search, directory *Directory) bool {
	s := search.FindBy["--size"]
	num, err := strconv.Atoi(s)
	if search.FindDir {
		var res int64 = 0
		for _, val := range directory.MapFiles {
			res += val.Size
		}
		if int64(num) == res && err == nil {
			return true
		}
		return false
	} else {
		if int64(num) == file.Size && err == nil {
			return true
		}
		return false
	}
}
