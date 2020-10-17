import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  categories;
  constructor(private categoryService: CategoryService) { }
  ngOnInit() {
    this.categoryService.getCategories().subscribe(a => this.categories = a);
  }

}
