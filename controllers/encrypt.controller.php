<?php

class EncrypController {

    static public function getEncrypt($password){
        return password_hash($password, PASSWORD_DEFAULT);
    }
    
    static public function getDecrypt($password, $encrypt){
        if (password_verify($password, $encrypt)) {
            return true;
        } else {
            return false;
        } 
    }
}