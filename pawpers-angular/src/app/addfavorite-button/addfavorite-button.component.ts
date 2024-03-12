import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Favorite } from '../AngularModels/favorite';
import { Profile } from '../AngularModels/profile';
import { ProfileApiService } from '../services/profile-api.service';

@Component({
  selector: 'app-addfavorite-button',
  templateUrl: './addfavorite-button.component.html',
  styleUrls: ['./addfavorite-button.component.css']
})
export class AddfavoriteButtonComponent implements OnInit {

  userEmail: any = ''
  profileId: number = 0

  favorite: Favorite = {} as Favorite

  @Input() dogId: number = 0

  show: boolean = true

  constructor(private http: HttpClient, private profileApi: ProfileApiService, private router: Router, public auth: AuthService) {
    this.checkIfFavorite()
  }

  ngOnInit(): void {
    this.getProfileId()
  }

  checkIfFavorite() {
    this.profileApi.viewProfileFavoritesByProfileId(this.favorite.profileId).subscribe(response => {
      response.$values.forEach((element: any) => {
        if (element.dogId == this.favorite.dogId) {
          this.show = false
        }
      });
    })
  }

  addDogToFavorite() {
    console.log("clicked")
    this.favorite.dogId = this.dogId
    this.favorite.isAvailable = 1
    this.favorite.profileId = this.profileId
    this.profileApi.addDogToFavorite(this.favorite).subscribe(response => {
      this.show = false
    })
  }

  getProfileId() {
    this.auth.user$.subscribe(response => {
      this.userEmail = response?.email
      this.profileApi.getProfileByEmail(this.userEmail).subscribe(element => {
        this.profileId = element.profileId
        console.log(this.profileId)
      })
    })
  }

}
