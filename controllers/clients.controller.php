<?php

class ControllerClients {
    public function show($id){
        if($id == null){
            $clients = ModelClients::show(null);
            message("message", $clients);
        } else {
            $clients = ModelClients::show($id);
            message("message", $clients);
        }
    }

    public function showArray(){
        $views = [];
        $views['groups'] = ModelClients::showArray('groups');
        $views['segments'] = ModelClients::showArray('segments');
        $views['salepersons'] = ModelClients::showArray('salepersons');
        $views['pharmacychains'] = ModelClients::showArray('pharmacychains');
        message("message", $views);
    }

    public function create($fields){
        if(!isset($fields->status) || !is_bool($fields->status)){
            messageErrorCode("The *status* field is incorrect",200);
        }
        if(!isset($fields->name) || $fields->name == ''){
            messageErrorCode("The *name* field is incorrect",200);
        }
        if(!isset($fields->lastname) || $fields->lastname == ''){
            messageErrorCode("The *lastname* field is incorrect",200);
        }
        if(!isset($fields->username) || $fields->username == ''){
            messageErrorCode("The *username* field is incorrect",200);
        }
        if(!isset($fields->password) || $fields->password == ''){
            messageErrorCode("The *password* field is incorrect",200);
        }
        if(!isset($fields->rol) || !is_numeric($fields->rol)){
            messageErrorCode("The *rol* field is incorrect",200);
        }

        $usernameRepeat = ModelClients::showForUsername($fields->username);

        if($usernameRepeat){
            messageErrorCode('Nombre de usuario existente',200);
        }

        $status = ModelClients::create($fields);

        if($status['status'] == 'success'){
            message('message','Usuario creado correctamente');
        }
    }

    public function put($fields){
        if(!isset($fields->id) || !is_numeric($fields->id)){
            messageErrorCode("The *id* field is incorrect",200);
        }
        if(!isset($fields->idsap) || !is_numeric($fields->idsap)){
            messageErrorCode("The *idsap* field is incorrect",200);
        }
        if(!isset($fields->fullname) || $fields->fullname == ''){
            messageErrorCode("The *fullname* field is incorrect",200);
        }
        if(!isset($fields->email)){
            messageErrorCode("The *email* field is incorrect",200);
        }
        if(!isset($fields->phone1) || !is_numeric($fields->phone1)){
            $fields->phone1 = 0;
            // messageErrorCode("The *phone1* field is incorrect",200);
        }
        if(!isset($fields->phone2) || !is_numeric($fields->phone2)){
            $fields->phone2 = 0;
            // messageErrorCode("The *phone2* field is incorrect",200);
        }
        if(!isset($fields->phone3) || !is_numeric($fields->phone3)){
            $fields->phone3 = 0;
            // messageErrorCode("The *phone3* field is incorrect",200);
        }
        if(!isset($fields->rfc) || $fields->rfc == ''){
            messageErrorCode("The *rfc* field is incorrect",200);
        }
        if(!isset($fields->concatperson)){
            $fields->concatperson = "";
            // messageErrorCode("The *rfc* field is incorrect",200);
        }
        if(!isset($fields->status) || !is_bool($fields->status)){
            messageErrorCode("The *status* field is incorrect",200);
        }
        if(!isset($fields->idsegment) || !is_numeric($fields->idsegment)){
            messageErrorCode("The *idsegment* field is incorrect",200);
        }
        if(!isset($fields->idsaleperson) || !is_numeric($fields->idsaleperson)){
            messageErrorCode("The *idsegment* field is incorrect",200);
        }
        if(!isset($fields->idgroup) || !is_numeric($fields->idgroup)){
            messageErrorCode("The *idsegment* field is incorrect",200);
        }
        if(!isset($fields->idpharmacychain) || !is_numeric($fields->idpharmacychain)){
            messageErrorCode("The *idsegment* field is incorrect",200);
        }

        $status = ModelClients::put($fields);

        if($status['status'] == 'success'){
            message('message','Cliente actualizado correctamente');
        }
    }

    public function delete($id, $status){
        if(!isset($id) || !is_numeric($id)){
            messageErrorCode("The *id* field is incorrect",200);
        }
        if(!isset($status) || !is_bool($status)){
            messageErrorCode("The *status* field is incorrect",200);
        }

        $response = ModelClients::delete($id,$status);


        if($response['status'] == 'success'){
            message('message',"El usuario ha sido {$response['response']}");
        }
    }
}