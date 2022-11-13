import { Component, OnInit } from '@angular/core';
import { offer } from '../data/models/offer';
import { OfferService } from '../services/offer.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  offers!: offer[];

  displayedColumns: string[] = ['Title', 'Category', 'Type', 'Score', 'Go to'];
  constructor(
    private offerService: OfferService
  ) { }

  ngOnInit(): void {
    this.offerService.getAll().subscribe(next => this.offers = next);
  }

}
