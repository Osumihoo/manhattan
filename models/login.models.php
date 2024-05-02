<?php

class ModelLogin{
    static public function validar($fields){
        $stmt = Connection::conect()->prepare("SELECT 
                                                e.*, 
                                                r.name namerol, 
                                                CASE
                                                WHEN e.`departament` = 1 THEN 'VENTAS'
                                                WHEN e.`departament` = 2 THEN 'COMPRAS'
                                                ELSE 'ADMIN'
                                                END 'type'
                                                FROM employers e 
                                                INNER JOIN roles r ON r.id = e.idrole
                                                WHERE username = :username");

        $stmt -> bindParam(":username", $fields->username, PDO::PARAM_STR);
        
        $stmt->execute();
        
        $result = $stmt->fetchAll(PDO::FETCH_ASSOC);
        
        if(sizeof($result) === 0) messageErrorCode("Valida tu usuario nuevamente",200);

        if(EncrypController::getDecrypt($fields->password, $result[0]['password'])){
            unset($result[0]['password']);
            if(!$result[0]['status']) messageErrorCode('Usuario desactivado',200);
            return array("status"=>"success", "user"=>$result[0]);
        } else {
            messageErrorCode("Valida tus credenciales",200);
        }
    }
}