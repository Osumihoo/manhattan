<?php

class ControllerEmployers {
    public function show($id){
        if($id == null){
            $employers = ModelEmployers::show(null);
            message("message", $employers);
        } else {
            $employers = ModelEmployers::show($id);
            message("message", $employers);
        }
    }

    public function showUsersSap(){
        $employers = ModelEmployers::show(null);

        $idSap = "";
        foreach($employers as $employer){
            if($employer['rol'] != 1) {
                $idSap .=  $employer['code'].",";
            }
        }

        if($idSap == "") $idSap = "0";
        else $idSap = substr($idSap,0,-1);
        
        $userSap = ModelEmployers::showForUsernameSap($idSap);

        echo json_encode($userSap);
        // if($id == null){
        //     $employers = ModelEmployers::show(null);
        //     message("message", $employers);
        // } else {
        //     $employers = ModelEmployers::show($id);
        //     message("message", $employers);
        // }
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
        if($fields->rol == 2){
            if(!isset($fields->sap->empID) || !is_numeric($fields->sap->empID)){
                messageErrorCode("The *empID* field is incorrect",200);
            }
            if(!isset($fields->sap->Code) || !is_numeric($fields->sap->Code)){
                messageErrorCode("The *Code* field is incorrect",200);
            }
            if(!isset($fields->sap->firstName) || $fields->sap->firstName == ''){
                messageErrorCode("The *firstName* field is incorrect",200);
            }
            if(!isset($fields->sap->lastName) || $fields->sap->lastName == ''){
                messageErrorCode("The *lastName* field is incorrect",200);
            }
            if(!isset($fields->sap->salesPrson) || !is_numeric($fields->sap->salesPrson)){
                messageErrorCode("The *salesPrson* field is incorrect",200);
            }
            if(!isset($fields->sap->idposition) || !is_numeric($fields->sap->idposition)){
                messageErrorCode("The *idposition* field is incorrect",200);
            }
            if(!isset($fields->sap->dept) || !is_numeric($fields->sap->dept)){
                messageErrorCode("The *dept* field is incorrect",200);
            }
            if(!isset($fields->sap->CostCenter) || !is_numeric($fields->sap->CostCenter)){
                messageErrorCode("The *CostCenter* field is incorrect",200);
            }
        }

        $usernameRepeat = ModelEmployers::showForUsername($fields->username);
        
        if($usernameRepeat){
            messageErrorCode('Nombre de usuario existente',200);
        }
        
        if($fields->rol == 1) $status = ModelEmployers::create($fields);
        if($fields->rol == 2) $status = ModelEmployers::createSAP($fields);
        

        if($status['status'] == 'success'){
            message('message','Usuario creado correctamente');
        }
    }

    public function put($fields){
        if(!isset($fields->id) || !is_numeric($fields->id)){
            messageErrorCode("The *id* field is incorrect",200);
        }
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
        if(!isset($fields->rol) || !is_numeric($fields->rol)){
            messageErrorCode("The *rol* field is incorrect",200);
        }

        $status = ModelEmployers::put($fields);

        if($status['status'] == 'success'){
            message('message','Usuario actualizado correctamente');
        }
    }

    public function delete($id, $status){
        if(!isset($id) || !is_numeric($id)){
            messageErrorCode("The *id* field is incorrect",200);
        }
        if(!isset($status) || !is_bool($status)){
            messageErrorCode("The *status* field is incorrect",200);
        }

        $response = ModelEmployers::delete($id,$status);


        if($response['status'] == 'success'){
            message('message',"El usuario ha sido {$response['response']}");
        }
    }
}