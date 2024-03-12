import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { dogSearchRoot } from '../dog-search/dog-search-model';
import { Organization } from '../dog-view/dog-view-model';
import { DogSearchService } from '../services/dog-search.service';


@Component({
  selector: 'app-shelterview-page',
  templateUrl: './shelterview-page.component.html',
  styleUrls: ['./shelterview-page.component.css']
})
export class ShelterviewPageComponent implements OnInit {
  searchResults: dogSearchRoot = {
    animals: [],
  };
  organization: any = {}

  constructor(private dogSearchService: DogSearchService, private router:Router, private route: ActivatedRoute) {
    let id = String(this.route.snapshot.paramMap.get("id"))
    this.getShelterInfo(id)
    this.viewShelter(id)
  }

  getShelterInfo(shelterId: string) {
    this.dogSearchService.shelterSingle(shelterId).then(
      resp => {
        this.organization = resp.data.organization
      }
    )
  }

  viewShelter(shelterId: string) {
    this.dogSearchService.shelterView(shelterId).then(
      resp => {
        resp.data.animals.forEach((element: any) => {
          if (element.photos[0] != null  && element.status == "adoptable") {
            this.searchResults.animals.push(element)
          }
        });
      }
    )
  }

  ngOnInit(): void {
  }

}
