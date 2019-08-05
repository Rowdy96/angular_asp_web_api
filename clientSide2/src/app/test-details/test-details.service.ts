import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TestDetails } from '../shared/TestDetails';



@Injectable({
  providedIn: 'root'
})
export class TestDetailsService {

  constructor(private _http : HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  getTestDetails(id : number) : Observable<TestDetails[]>{
        return this._http.get<TestDetails[]>("https://localhost:44357/api/TestDetails/GetAllTestDetail/"+id);
  }

  getTestDetailsById(id : number) : Observable<TestDetails>{
    debugger;
    return this._http.get<TestDetails>("https://localhost:44357/api/TestDetails/GetTestDetail/"+id);
  }

  updateDetails(id: number , testDetails : TestDetails) : Observable<TestDetails>{
    const updateUrl = "https://localhost:44357/api/TestDetails/EditTestDetail/"+id; 
    debugger;
    return this._http.put<TestDetails>(updateUrl,testDetails);
  }

  createDetails(testDetails: TestDetails,testid):Observable<TestDetails>{
    const createUrl ="https://localhost:44357/api/TestDetails/CreateTestDetail/"+testid;
    return this._http.post<TestDetails>(createUrl,testDetails);
  }

  deleteDetails(id : number) : Observable<{}>{
    const url= "https://localhost:44357/api/TestDetails/DeleteTestDetail/"+id;
    return this._http.delete(url);
  }
}
