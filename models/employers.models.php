<?php

require_once "connections/connection.php";

class  ModelEmployers{
    static public function show($id){
        if($id == null) $stmt = Connection::conect()->prepare('SELECT e.id,
                                                               e.name,
                                                               e.lastname,
                                                               e.username,
                                                               e.status,
                                                               e.idrole rol, 
                                                               e.empID,
                                                               e.code,
                                                               e.salePerson,
                                                               e.position,
                                                               e.departament,
                                                               e.costCenter,
                                                               r.name namerol
                                                               FROM employers e
                                                               INNER JOIN roles r ON r.id = e.idrole'
                                                            );
        else $stmt = Connection::conect()->prepare("SELECT e.id,
                                                    e.name,
                                                    e.lastname,
                                                    e.username,
                                                    e.status,
                                                    e.idrole rol, 
                                                    e.empID,
                                                    e.code,
                                                    e.salePerson,
                                                    e.position,
                                                    e.departament,
                                                    e.costCenter,
                                                    r.name namerol
                                                    FROM employers e
                                                    INNER JOIN roles r ON r.id = e.idrole
                                                    WHERE e.id = {$id}"
                                                  );

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

    static public function showForUsernameSap($idSap){
        $database = $_ENV['DB_DATABASE_SAP'];
        $stmt = Connection::conectsap()->prepare("select	
                                                    T0.\"empID\",
                                                    T0.\"Code\",
                                                    T0.\"Active\",
                                                    T0.\"firstName\",
                                                    T0.\"lastName\",
                                                    T0.\"salesPrson\",
                                                    T0.\"position\" AS \"idposition\",
                                                    T0.\"dept\",
                                                    T0.\"CostCenter\",
                                                    T1.\"Name\" AS \"position\",
                                                    T2.\"name\" AS \"departament\"
                                                    from {$database}.\"OHEM\" T0
                                                    INNER JOIN {$database}.\"OUDP\" T1 ON T1.\"Code\" = T0.\"dept\"
                                                    INNER JOIN {$database}.\"OHPS\" T2 ON T2.\"posID\" = T0.\"position\"
                                                    WHERE T1.\"Name\" IN ('Ventas de DeOfta','Compras de DeOfta')
                                                    AND T0.\"Code\" NOT IN ({$idSap})");

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

    static public function createSAP($fields){
        $stmt = Connection::conect()->prepare("INSERT INTO `employers` (`name`, `lastname`, `username`, `password`, `status`, `idrole`, `empID`,`code`,`salePerson`,`position`,`departament`,`costCenter`) VALUES (:name, :lastname, :username, :password, :status, :idrole, :empID, :code, :salePerson, :position, :departament, :costCenter)");
        $password = EncrypController::getEncrypt($fields->password);

        $stmt -> bindParam(":name", $fields->name, PDO::PARAM_STR);
        $stmt -> bindParam(":lastname", $fields->lastname, PDO::PARAM_STR);
        $stmt -> bindParam(":username", $fields->username, PDO::PARAM_STR);
        $stmt -> bindParam(":password", $password, PDO::PARAM_STR);
        $stmt -> bindParam(":idrole", $fields->rol, PDO::PARAM_STR);
        $stmt -> bindParam(":status", $fields->status, PDO::PARAM_STR);
        $stmt -> bindParam(":empID", $fields->sap->empID, PDO::PARAM_STR);
        $stmt -> bindParam(":code", $fields->sap->Code, PDO::PARAM_STR);
        $stmt -> bindParam(":salePerson", $fields->sap->salesPrson, PDO::PARAM_STR);
        $stmt -> bindParam(":position", $fields->sap->idposition, PDO::PARAM_STR);
        $stmt -> bindParam(":departament", $fields->sap->dept, PDO::PARAM_STR);
        $stmt -> bindParam(":costCenter", $fields->sap->CostCenter, PDO::PARAM_STR);
        if($stmt->execute()) return array("status"=>"success", "id"=>Connection::conect()->lastInsertId());
        else messageErrorCode(Connection::conect()->errorInfo(),200);

        // $stmt->close();

        $stmt=null;
    }
    
    static public function put($fields){
        if(!isset($fields->password) || $fields->password == ''){
            $stmt = Connection::conect()->prepare('UPDATE employers SET name=:name, lastname=:lastname, username=:username, status=:status, idrole=:idrole WHERE id=:id');
            $stmt -> bindParam(":id", $fields->id, PDO::PARAM_STR);
            $stmt -> bindParam(":name", $fields->name, PDO::PARAM_STR);
            $stmt -> bindParam(":lastname", $fields->lastname, PDO::PARAM_STR);
            $stmt -> bindParam(":username", $fields->username, PDO::PARAM_STR);
            $stmt -> bindParam(":idrole", $fields->rol, PDO::PARAM_STR);
            $stmt -> bindParam(":status", $fields->status, PDO::PARAM_STR);
        }else {
            $stmt = Connection::conect()->prepare('UPDATE employers SET name=:name, lastname=:lastname, username=:username, password=:password, status=:status, idrole=:idrole WHERE id=:id');
            $password = EncrypController::getEncrypt($fields->password);
            $stmt -> bindParam(":id", $fields->id, PDO::PARAM_STR);
            $stmt -> bindParam(":name", $fields->name, PDO::PARAM_STR);
            $stmt -> bindParam(":lastname", $fields->lastname, PDO::PARAM_STR);
            $stmt -> bindParam(":username", $fields->username, PDO::PARAM_STR);
            $stmt -> bindParam(":password", $password, PDO::PARAM_STR);
            $stmt -> bindParam(":idrole", $fields->rol, PDO::PARAM_STR);
            $stmt -> bindParam(":status", $fields->status, PDO::PARAM_STR);
        }

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