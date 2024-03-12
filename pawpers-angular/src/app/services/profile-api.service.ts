import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Profile, Main } from '../AngularModels/profile';
import { Favorite } from '../AngularModels/favorite';

@Injectable({
  providedIn: 'root'
})
export class ProfileApiService {

  private endpoint:string = "https://pawpers.azurewebsites.net";

  constructor(private http:HttpClient) { }

  createProfile(profile:Profile)
  {
    return this.http.post<Main['$values']>(this.endpoint + "/Profile/Create", profile);
  }

  viewProfileFavoritesByProfileId(profileId: number)
  {
    return this.http.get<any>(this.endpoint + "/Favorite/SearchByProfile/" + profileId)
  }

  getProfileByEmail(email: string) {
    return this.http.get<any>(this.endpoint + "/Profile/GetEmail/" + email)
  }

  getState(stateId: number) {
    return this.http.get<any>(this.endpoint + "/State/Get/" + stateId)
  }

  addDogToFavorite(favorite: Favorite) {
    return this.http.post<any>(this.endpoint + "/Favorite/Create", favorite)
  }

  removeFavorite(favoriteId: number) {
    return this.http.delete<any>(this.endpoint + "/Favorite/Delete/" + favoriteId)
  }
}
