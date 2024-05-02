<?php

require_once "connections/connection.php";

class  ModelClients{
    static public function showArray($table){
        $stmt = Connection::conect()->prepare("SELECT id value, name FROM {$table}");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
    
    static public function show($id){
        if($id == null) $stmt = Connection::conect()->prepare('SELECT c.id, c.idsap, c.fullname, c.email, c.phone1, c.phone2, c.phone3, c.rfc, c.concatperson, c.status,
                                                                      s.name segment, s.id idsegment, sa.name saleperson, sa.id idsaleperson, g.name namegroup, g.id idgroup, p.name pharmacychain, p.id idpharmacychain
                                                                      FROM `clients` c
                                                                      INNER JOIN `segments` s ON s.id = c.idsegment
                                                                      INNER JOIN `salepersons` sa ON sa.id = c.idsaleperson 
                                                                      INNER JOIN `groups` g ON g.id = c.idgroup
                                                                      INNER JOIN `pharmacychains` P ON p.id = c.idpharmacychain');
        else $stmt = Connection::conect()->prepare("SELECT c.id, c.idsap, c.fullname, c.email, c.phone1, c.phone2, c.phone3, c.rfc, c.concatperson, c.status,
        s.name segment, s.id idsegment, sa.name saleperson, sa.idsap idsaleperson, g.name namegroup, g.id idgroup, p.name pharmacychain, p.id idpharmacychain
        FROM `clients` c
        INNER JOIN `segments` s ON s.id = c.idsegment
        INNER JOIN `salepersons` sa ON sa.id = c.idsaleperson 
        INNER JOIN `groups` g ON g.id = c.idgroup
        INNER JOIN `pharmacychains` P ON p.id = c.idpharmacychain
        WHERE c.id = {$id}");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }

    static public function showForUsername($username){
        $stmt = Connection::conect()->prepare("SELECT * FROM `employers` WHERE `username` = '{$username}'");

        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);

        // $stmt->close();

        $stmt=null;
    }
 
    static public function create($fields){
        $stmt = Connection::conect()->prepare("INSERT INTO `employers` (`name`, `lastname`, `username`, `password`, `status`, `idrole`) VALUES (:name, :lastname, :username, :password, :status, :idrole)");
        $password = EncrypController::getEncrypt($fields->password);

        $stmt -> bindParam(":name", $fields->name, PDO::PARAM_STR);
        $stmt -> bindParam(":lastname", $fields->lastname, PDO::PARAM_STR);
        $stmt -> bindParam(":username", $fields->username, PDO::PARAM_STR);
        $stmt -> bindParam(":password", $password, PDO::PARAM_STR);
        $stmt -> bindParam(":idrole", $fields->rol, PDO::PARAM_STR);
        $stmt -> bindParam(":status", $fields->status, PDO::PARAM_STR);

        if($stmt->execute()) return array("status"=>"success", "id"=>Connection::conect()->lastInsertId());
        else messageErrorCode(Connection::conect()->errorInfo(),200);

        // $stmt->close();

        $stmt=null;
    }
    
    static public function put($fields){
       
            $stmt = Connection::conect()->prepare('UPDATE `clients` SET `id`=:id,`idsap`=:idsap,`status`=:status,`fullname`=:fullname,`email`=:email,`phone1`=:phone1,`phone2`=:phone2,`phone3`=:phone3,`rfc`=:rfc,`concatperson`=:concatperson,`idsegment`=:idsegment,`idgroup`=:idgroup,`idsaleperson`=:idsaleperson,`idpharmacychain`=:idpharmacychain WHERE id=:id');
            $stmt -> bindParam(":id", $fields->id, PDO::PARAM_STR);
            $stmt -> bindParam(":idsap", $fields->idsap, PDO::PARAM_STR);
            $stmt -> bindParam(":status", $fields->status, PDO::PARAM_STR);
            $stmt -> bindParam(":fullname", $fields->fullname, PDO::PARAM_STR);
            $stmt -> bindParam(":email", $fields->email, PDO::PARAM_STR);
            $stmt -> bindParam(":username", $fields->username, PDO::PARAM_STR);
            $stmt -> bindParam(":phone1", $fields->phone1, PDO::PARAM_STR);
            $stmt -> bindParam(":phone2", $fields->phone2, PDO::PARAM_STR);
            $stmt -> bindParam(":phone3", $fields->phone3, PDO::PARAM_STR);
            $stmt -> bindParam(":rfc", $fields->rfc, PDO::PARAM_STR);
            $stmt -> bindParam(":concatperson", $fields->concatperson, PDO::PARAM_STR);
            $stmt -> bindParam(":idsegment", $fields->idsegment, PDO::PARAM_STR);
            $stmt -> bindParam(":idgroup", $fields->idgroup, PDO::PARAM_STR);
            $stmt -> bindParam(":idsaleperson", $fields->idsaleperson, PDO::PARAM_STR);
            $stmt -> bindParam(":idpharmacychain", $fields->idpharmacychain, PDO::PARAM_STR);

        if($stmt->execute()) return array("status"=>"success");
        else messageErrorCode(Connection::conect()->errorInfo(),200);

        // $stmt->close();

        $stmt=null;
    }

    static public function delete($id, $status){
        $stmt = Connection::conect()->prepare("UPDATE employers SET status=:status WHERE id=:id");
        $stmt -> bindParam(":id", $id, PDO::PARAM_STR);
        $stmt -> bindParam(":status", $status, PDO::PARAM_STR);

        if($stmt->execute()) return array("status"=>"success", "response" => $status ? "activado" : "desactivado");
        else messageErrorCode(Connection::conect()->errorInfo(),200);

        // $stmt->close();

        $stmt=null;
    }
}