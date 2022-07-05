/* eslint-disable linebreak-style */
/* eslint-disable import/prefer-default-export */
export class AccountsModel {
  email:string;

  password:string;

  constructor(email:string, password:string) {
    this.email = email;
    this.password = password;
  }
}
