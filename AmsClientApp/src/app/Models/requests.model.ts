/* eslint-disable linebreak-style */
/* eslint-disable import/prefer-default-export */
export class RequestsModel {
  purpose:string;

  approver:string;

  estimatedCost:number;

  advanceAmount:number;

  description:string;

  planDate:Date;

  user:number;

  managerId:number;

  rejectedReason: string;

  constructor(

    purpose:string,
    approver:string,
    estimatedCost:number,
    advanceAmount:number,
    description:string,
    planDate:Date,
    user:number,
    rejectedReason: string,
  ) {
    this.purpose = purpose;
    this.approver = approver;
    this.estimatedCost = estimatedCost;
    this.advanceAmount = advanceAmount;
    this.description = description;
    this.planDate = planDate;
    this.user = user;
    this.rejectedReason = rejectedReason;
  }
}
