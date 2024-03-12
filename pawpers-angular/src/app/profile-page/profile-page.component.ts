import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Main } from '../AngularModels/profile';
import { AuthService } from '@auth0/auth0-angular';
import { ProfileApiService } from '../services/profile-api.service';
import { DogSearchService } from '../services/dog-search.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  profileId: any
  profileExists: boolean = false
  userEmail: any = ''
  profile: any = {}
  state: any = ''
  hasChildren: string = ''
  dwellingType: string = ''
  hasYard: string = ''
  familyAllergies: string = ''

  recommended: any = []

  constructor(private profileApi: ProfileApiService, private router: Router, public auth: AuthService, private dogSearchService: DogSearchService) {
    this.auth.user$.subscribe((result) => {
      this.userEmail = result?.email;

      this.profileApi.getProfileByEmail(this.userEmail).subscribe(response => {
        if (response.profileEmail == this.userEmail) {
          this.profileExists = true
        }

        this.profile = response
        this.profileId = this.profile.profileId
        console.log(this.profileId)
        this.hasChildren = this.yesOrNo(this.profile.profileChildren)
        this.getDwellingType(this.profile.profileDwellingid)
        this.hasYard = this.yesOrNo(this.profile.profileHasyard)
        this.familyAllergies = this.yesOrNo(this.profile.profileFamilyalergies)

        this.getRecommended(this.profile.profileZipcode)
      })

    })
  }

  getState(stateId: number) {
    this.profileApi.getState(stateId).subscribe(response => {
      this.state = response.stateName
    })
  }

  yesOrNo(num: number) {
    if (num == 1) {
      return "Yes"
    }
    return "No"
  }

  getDwellingType(num: number) {
    if (num == 1) {
      this.dwellingType = "House"
    } else if (num == 2) {
      this.dwellingType = "Apartment"
    } else if (num == 3) {
      this.dwellingType = "Condo"
    } else {
      this.dwellingType = "Other"
    }
  }

  getRecommended(zipCode: number) {
    let count = 0
    this.dogSearchService.dogSearch(zipCode).then(response => {
      response.data.animals.forEach((element: any) => {
        if (count < 5) {
          if (this.profile.profileChildren == 1 && element.environment.children == true) {
            this.recommended.push(element)
          }
          else if (this.profile.profileOtherpetname != null && element.environment.dogs == true) {
            this.recommended.push(element)
          }
          else if (this.profile.profileChildren == 2 && this.profile.profileOtherpetname == null) {
            this.recommended.push(element)
          }
          else {
            this.recommended.push(element)
          }
        }

        count++
      })
      console.log("RECOMMENDED", this.recommended)
    })
  }

  ngOnInit(): void {
  }

  redirectToAddProfile() {
    this.router.navigateByUrl('add-profile');
  }
}
