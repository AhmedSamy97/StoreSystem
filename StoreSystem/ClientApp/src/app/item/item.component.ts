import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemService } from './../Services/item.service';
import { cloneDeep } from 'lodash';
import { NgbModal, ModalDismissReasons, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  @ViewChild('warning', null) t1: ElementRef;
  constructor(private router: ActivatedRoute, private itemService: ItemService, private r: Router, private modalService: NgbModal) { }
  ItemData;
  price: number = 0;
  myArr;
  id;
  MinQty = 1;
  closeResult = '';
  modalReference: NgbModalRef;

  ngOnInit() {
    this.id = this.router.snapshot.paramMap.get('id');
    this.itemService.getItemDataPerSubCategory(this.id).subscribe(d => {
      this.ItemData = d;
      const myClonedArray = cloneDeep(this.ItemData.quantities);
      this.myArr = myClonedArray;
    });

  }
  Add() {
    if (this.ItemData != null && this.ItemData.qtys > 0) {
      this.ItemData.qtys -= 1;

      //Check minQty 
      if (this.ItemData.qtys <= this.MinQty) {
        this.open(this.t1);
      }
      this.decrementQty();
    }
  }

  decrementQty() {
    let i = 0;
    while (this.ItemData.qtys >= 0) {
      if (this.ItemData.quantities[i] > 0) {
        this.ItemData.quantities[i] -= 1;
        break;
      }
      else {
        i++;
      }
    }
  }
  CalculatePrice() {
    if (this.ItemData != null) {
      for (let index = 0; index < this.ItemData.quantities.length; index++) {
        let qty = this.myArr[index] - this.ItemData.quantities[index];
        this.price += qty * this.ItemData.prices[index];
      }
    }

  }

  placeOrder() {
    this.itemService.EditQuatity(this.id, this.ItemData.quantities).subscribe(data => {
      //Close PopUp
      this.modalReference.close();
      //Redirect
      this.r.navigateByUrl("/");
    });
  }
  open(content) {
    this.modalReference = this.modalService.open(content);
    this.modalReference.result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
    //rest The Price
    this.price = 0;
    this.CalculatePrice();
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

}
