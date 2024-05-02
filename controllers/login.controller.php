<?php
class ControllerLogin{
    public function validar($fields){
        if(!isset($fields->username) || $fields->username == ''){
            messageErrorCode("The *username* field is incorrect",200);
        }
        if(!isset($fields->password) || $fields->password == ''){
            messageErrorCode("The *password* field is incorrect",200);
        }

        $login = new ModelLogin();
        $status = $login::validar($fields);

        if($status['status'] == 'success'){
            message('message',$status['user']);
        }
    }
}