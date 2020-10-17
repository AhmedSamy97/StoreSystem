import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SubcategoriesService } from './../Services/subcategories.service';

@Component({
  selector: 'app-sub-category',
  templateUrl: './sub-category.component.html',
  styleUrls: ['./sub-category.component.css']
})
export class SubCategoryComponent implements OnInit {

  constructor(private subcategoryService: SubcategoriesService, private router: ActivatedRoute) { }
  subCategories;
  ngOnInit() {
    const id = this.router.snapshot.paramMap.get('id');
    this.subcategoryService.getAllSubCategories(id).subscribe(sub => this.subCategories = sub);

  }

}
