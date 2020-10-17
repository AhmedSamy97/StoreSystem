import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SubcategoriesService {

  constructor(private http: HttpClient) { }
  getAllSubCategories(id) {
    return this.http.get("/api/SubCategory/" + id);
  }
}
