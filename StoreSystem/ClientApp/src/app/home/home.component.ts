import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  data;
  constructor(private categoryService: CategoryService) { }
  ngOnInit() {
    this.categoryService.getCategories().subscribe(a => this.data = a);
  }

}
