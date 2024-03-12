import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfileApiService } from '../services/profile-api.service';
import { Profile } from '../AngularModels/profile';
import { Main, Favorite } from '../AngularModels/favorite';
import { DogSearchService } from '../services/dog-search.service';

@Component({
  selector: 'app-favorites-page',
  templateUrl: './favorites-page.component.html',
  styleUrls: ['./favorites-page.component.css']
})
export class FavoritesPageComponent implements OnInit {

  @Input() profileId: number = 0

  favorites: any= []
  dog: any = {}

  constructor(private dogSearchService: DogSearchService, private profileApi: ProfileApiService, private router: Router, private route: ActivatedRoute) {
    // let profileId = Number(this.route.snapshot.paramMap.get("id")) 
  }

  ngOnInit(): void {
    this.getProfileWithFavorites(this.profileId)
    console.log("FAVORITES: ", this.favorites)
  }

  getProfileWithFavorites(profileId: number) {
    this.profileApi.viewProfileFavoritesByProfileId(profileId).subscribe(response => {
      response.$values.forEach((element: any) => {
        if (response.status == 404) {
          return
        } else {
          this.getDogById(element.dogId)
        }
      })
  })
}

  getDogById(dogId: number) {
    this.dogSearchService.viewDog(dogId).then(doggo => {
      this.favorites.push(doggo.data.animal)
  })
  .catch(err => {
    console.log(err.request, err.response);
    // See invalid parameters `err.invalidParams`
  });
}
}
