/* eslint-disable linebreak-style */
/* eslint-disable import/prefer-default-export */
export class AccountsModel {
  id:number;

  name:string;

  email:string;

  password:string;

  constructor(id:number, name:string, email:string, password:string) {
    this.id = id;
    this.name = name;
    this.email = email;
    this.password = password;
  }
}
