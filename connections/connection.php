<?php 

require_once "server.php";

class Connection{ 
    static public function conect(){
        $link= new PDO(KeyServer::StringConnection(),KeyServer::StringUser() ,KeyServer::StringPwd());
        
        $link->exec("set names utf8");

        return $link;
    }

    static public function conectsap(){
        $link= new PDO(KeyServer::StringConnectionSap(),KeyServer::StringUserSap() ,KeyServer::StringPwdSap());
        
        return $link;
    }


}
