import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http: HttpClient) { }
  getItemDataPerSubCategory(id) {
    return this.http.get("/api/item/" + id);
  }

  EditQuatity(subcategoryId, qtysArr) {
    return this.http.put("/api/item", { subcategoryId, qtysArr });
  }
}
