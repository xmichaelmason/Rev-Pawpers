import { Component, Input, OnInit, SimpleChange, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DogSearchService } from '../services/dog-search.service';
import { Animal, dogViewRoot } from './dog-view-model';

@Component({
  selector: 'app-dog-view',
  templateUrl: './dog-view.component.html',
  styleUrls: ['./dog-view.component.css']
})
export class DogViewComponent implements OnInit {
  searchResult: dogViewRoot = {} as dogViewRoot

  constructor(private dogSearchService: DogSearchService, private router:Router, private route: ActivatedRoute) { 
    let id = Number(this.route.snapshot.paramMap.get("id"))
    this.viewDog(id)
  }

  viewDog(dogId: number) {
    this.dogSearchService.viewDog(dogId).then(
      resp => {
        this.searchResult.animal = resp.data.animal
      }
    )
  }

  ngOnInit(): void {
  }

}
