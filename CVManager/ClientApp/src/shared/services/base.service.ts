import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const BaseUrl = '/api/';
const GlobalBaseUrl = '';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json; charset=utf-8'
  })
};

const httpFormDataOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/x-www-form-urlencoded',
  })
};

@Injectable({ providedIn: 'root' })


export class BaseService {

  

  constructor(private http: HttpClient) {

  }

  post(Controller, Object) {
    return this.http.post(BaseUrl + Controller + "/PostItem", JSON.stringify(Object), httpOptions)
  }

  getById(Controller, Id: number) {
    return this.http.get(BaseUrl + Controller + "/GetById/" + Id)
  }

  getAllItems(Controller) {
    return this.http.get(BaseUrl + Controller + "/GetAllItems");
  }

  Edit(Controller, Object) {
    return this.http.post(BaseUrl + Controller + "/EditItem", JSON.stringify(Object), httpOptions)
  }

  getList(Controller: string , search) {
    return this.http.post(BaseUrl + Controller + "/GetList" , JSON.stringify(search) , httpOptions)
  }

  removeItem(controllerName: string, postobject) {
    return this.http.post(BaseUrl + controllerName + '/RemoveItem', JSON.stringify(postobject), httpOptions);
  }
  readJson(fileName) {
    return this.http.get('assets/' + fileName);
  }

}
