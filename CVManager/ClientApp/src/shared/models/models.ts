import { FormControl } from "@angular/forms";

export class TransferRequest {
  empNo: string
  empName: string
  effectiveMovingDate: Date
  oldSiteName: string
  newSiteName: string;
  oldDivisionName
  newDivisionName: string;
  oldDepartmentName: string;
  newDepartmentName: string;
  oldSectionName: string;
  newSectionName: string;
  oldRank: string;
  newRank: string;
  odSystemTitle: string;
  newSystemTitle: string;
  oldBusinessCardTitle: string;
  newBusinessCardTitle: string;
  oldFinancialType: string;
  newFinancialType: string;
  oldFinancialValue: string;
  newFinancialValue: string;
  oldTotalSalary: number;
  newTotalSalary: number
  hasTransportationAllowances: boolean
  transportationAllowancesValue: number
  hasRankAllowances: boolean
  rankAllowancesValue: number
  status: number
  oldManagerName: string
  newManagerName: string
}

export interface NavItem {
  displayName: string;
  disabled?: boolean;
  iconName: string;
  route?: string;
  children?: NavItem[];
}

export class WhiteSpace {

  public static noWhiteSpaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
  }

  public static isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
  }



}

export class ApprovalDto {
  transferRequestId: number
  approvalId: number;
  generalComment?: string;

  constructor(transferRequestId: number, approvalId: number, generalComment?: string) {
    this.transferRequestId = transferRequestId
    this.approvalId = approvalId
    this.generalComment = generalComment
  }

}

export class ActionDTO {
  approvalId :number
  transferRequestId :number
  comment?: string

  constructor(transferRequestId, approvalId, comment?) {
    this.approvalId = approvalId
    this.transferRequestId = transferRequestId
    this.comment = comment
  }

}

export class ApprovalStatusDTO {
  transferRequestId: number
  approvalTaskEnumId: number

  constructor(transferRequestId, approvalTaskEnumId) {
    this.transferRequestId = transferRequestId
    this.approvalTaskEnumId = approvalTaskEnumId
  }
}
