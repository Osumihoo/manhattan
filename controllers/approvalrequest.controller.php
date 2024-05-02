<?php

class ControllerApprovalRequest {
    public function WareHouseSN($CardCode,$Warehouse){
        try {                     
            $Approval = ModelApprovalRequest::WareHouseSN($CardCode,$Warehouse)['validation'];
            return boolval($Approval);
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }

    public function Counted($CardCode,$GroupNum){
        try {                     
            $Approval = ModelApprovalRequest::Counted($CardCode,$GroupNum)['validation'];
            return boolval($Approval);
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }

    public function CountedCC($CardCode){
        try {                     
            $Approval = ModelApprovalRequest::CountedCC($CardCode)['validation'];
            return boolval($Approval);
         }
         catch (Exception $e) {
            messageErrorCode($e->getMessage(),200);
         }
    }
    
    public function Credit($CardCode,$GroupNum,$lines){
      try {            
         $DocTotal = 0;
         $Taxes = 0;
         $Total = 0;
         foreach($lines as $line){
            $price = ((floatval($line->UnitPrice) * intval($line->Quantity)) - floor(floatval($line->DiscountPercent)*(floatval($line->UnitPrice) * intval($line->Quantity)))/100);
            $DocTotal += $price;
            if($line->TaxCode == 'IVAV16') $Taxes += ($price * 0.16);
         }
         $Total = $DocTotal + $Taxes;
         $Approval = ModelApprovalRequest::Credit($CardCode);
         
         $Approval = ModelApprovalRequest::CreditValidation($Approval,$Total,$GroupNum)['validation'];

         return boolval($Approval);
       }
       catch (Exception $e) {
          messageErrorCode($e->getMessage(),200);
       }
  }
}