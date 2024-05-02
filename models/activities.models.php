<?php

require_once "connections/connection.php";

class  ModelActivities{
    static public function create($fields,$start,$finish){
        $stmt = Connection::conect()->prepare("INSERT INTO `activity`(`comments`, `idactivity`, `idincident`, `idcancelation`, `idclient`, `startcall`, `finishcall`,`idemployer`,`timed`,`idstatus`) 
                                                            VALUES (:comments,:idactivity,:idincident,:idcancelation,:idclient,:startcall,:finishcall,:idemployer,:timed,:idstatus)");
        
        $stmt -> bindParam(":comments", $fields->comment, PDO::PARAM_STR);
        $stmt -> bindParam(":idemployer", $fields->employer, PDO::PARAM_STR);
        $stmt -> bindParam(":idstatus", $fields->status, PDO::PARAM_STR);
        $stmt -> bindParam(":timed", $fields->timed, PDO::PARAM_STR);
        $stmt -> bindParam(":idactivity", $fields->activity, PDO::PARAM_STR);
        $stmt -> bindParam(":idincident", $fields->incident, PDO::PARAM_STR);
        $stmt -> bindParam(":idcancelation", $fields->cancellation, PDO::PARAM_STR);
        $stmt -> bindParam(":idclient", $fields->user, PDO::PARAM_STR);
        $stmt -> bindParam(":startcall", $start, PDO::PARAM_STR);
        $stmt -> bindParam(":finishcall", $finish, PDO::PARAM_STR);

        if($stmt->execute()) return array("status"=>"success", "id"=>Connection::conect()->lastInsertId());
        else messageErrorCode(Connection::conect()->errorInfo(),200);

        // $stmt->close();

        $stmt=null;
    }

    static public function put($fields){
        if($fields->type == 'update') {
            $stmt = Connection::conect()->prepare("UPDATE `activity` SET `aditionalcomments`=:aditionalcomments
                                                    WHERE `id` = :id");
                                                    
            $stmt -> bindParam(":id", $fields->id, PDO::PARAM_STR);
            $stmt -> bindParam(":aditionalcomments", $fields->aditionalcomments, PDO::PARAM_STR);
        }
        
        if($fields->type == 'close') {
            $stmt = Connection::conect()->prepare("UPDATE `activity` SET `aditionalcomments`=:aditionalcomments, `idstatus`=:status
            WHERE `id` = :id");
            $close = 2;
            $stmt -> bindParam(":id", $fields->id, PDO::PARAM_STR);
            $stmt -> bindParam(":aditionalcomments", $fields->aditionalcomments, PDO::PARAM_STR);
            $stmt -> bindParam(":status", $close, PDO::PARAM_STR);
        }
        

        if($stmt->execute()) return array("status"=>"success", "id"=>Connection::conect()->lastInsertId());
        else messageErrorCode(Connection::conect()->errorInfo(),200);

        // $stmt->close();

        $stmt=null;
    }
}