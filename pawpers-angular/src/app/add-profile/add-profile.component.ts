import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Profile } from '../AngularModels/profile';
import { ProfileApiService } from '../services/profile-api.service';

@Component({
  selector: 'app-add-profile',
  templateUrl: './add-profile.component.html',
  styleUrls: ['./add-profile.component.css']
})
export class AddProfileComponent implements OnInit {

  userEmail:any = "";
  otherDogAge:number = 0;
  displayMessage:string = "";
  // errorMessage:string = "All required fields must be filled!";
  
  constructor(private profileSerrvice:ProfileApiService, public auth:AuthService, private router:Router) {
    this.auth.user$.subscribe((result) => {
      this.userEmail = result?.email;
    })
   }

  profileGroup:FormGroup = new FormGroup({
    profileName:              new FormControl("", [Validators.required]), //, Validators.required
    profileStreetaddress:     new FormControl("", Validators.required),
    profileCity:              new FormControl("", Validators.required),
    profileStateid:           new FormControl(""), 
    profileZipcode:           new FormControl("", Validators.required),
    profileAge:               new FormControl("", Validators.required),
    profileHomephone:         new FormControl(""),
    profilePersonalphone:     new FormControl("", Validators.required),
    profileEmail:             new FormControl(""), 
    profileOccupation:        new FormControl("", Validators.required),
    profileSpousename:        new FormControl(""),
    profileChildren:          new FormControl("", Validators.required),
    profileDwellingid:        new FormControl(""), 
    profileHasyard:           new FormControl("", Validators.required),
    profileLandlordname:      new FormControl(""),
    profileLandlordphone:     new FormControl(""),
    profileOtherpetname:      new FormControl(""),
    profileOtherpetbreed:     new FormControl(""),
    profileOtherpetsex:       new FormControl(""),
    profileOtherpetage:       new FormControl(""),
    profileFamilyallergies:   new FormControl("", Validators.required),
    profileResponsiblefordog: new FormControl("", Validators.required),
    profileAdoptionreason:    new FormControl("", Validators.required),
    profileDogsleepat:        new FormControl("", Validators.required),
    profileDogaggresive:      new FormControl("", Validators.required),
    profileMedfordog:         new FormControl("", Validators.required),
    profileNocaredog:         new FormControl("", Validators.required),
  });

  // gets for Form Validation
  get name() {return this.profileGroup.get("profileName");}
  get address() {return this.profileGroup.get("profileStreetaddress");}
  get city() {return this.profileGroup.get("profileCity");}
  get zipCode() {return this.profileGroup.get("profileZipcode");}
  get age() {return this.profileGroup.get("profileAge");}
  get phoneNumber() {return this.profileGroup.get("profilePersonalphone");}
  get occupation() {return this.profileGroup.get("profileOccupation");}
  get children() {return this.profileGroup.get("profileChildren");}
  get yard() {return this.profileGroup.get("profileHasyard");}
  get allergies() {return this.profileGroup.get("profileFamilyallergies");}
  get responsible() {return this.profileGroup.get("profileResponsiblefordog");}
  get reason() {return this.profileGroup.get("profileAdoptionreason");}
  get sleep() {return this.profileGroup.get("profileDogsleepat");}
  get aggressive() {return this.profileGroup.get("profileDogaggresive");}
  get medication() {return this.profileGroup.get("profileMedfordog");}
  get nocare() {return this.profileGroup.get("profileNocaredog");}

  ngOnInit(): void {
  }

  createProfile(profileGroup: FormGroup)
  {
    if (this.profileGroup.get("profileOtherpetage")?.value != "") {
      this.otherDogAge = this.profileGroup.get("profileOtherpetage")?.value;
      // console.log(this.otherDogAge)
    }
    
    if (this.profileGroup.valid) {
      let profile:Profile = {
        profileName:              this.profileGroup.get("profileName")?.value,
        profileStreetaddress:     this.profileGroup.get("profileStreetaddress")?.value,
        profileCity:              this.profileGroup.get("profileCity")?.value,
        profileStateid:           this.profileGroup.get("profileStateid")?.value,
        profileZipcode:           this.profileGroup.get("profileZipcode")?.value,
        profileAge:               this.profileGroup.get("profileAge")?.value,
        profileHomephone:         this.profileGroup.get("profileHomephone")?.value,
        profilePersonalphone:     this.profileGroup.get("profilePersonalphone")?.value,
        profileEmail:             this.userEmail,
        profileOccupation:        this.profileGroup.get("profileOccupation")?.value,
        profileSpousename:        this.profileGroup.get("profileSpousename")?.value,
        profileChildren:          this.profileGroup.get("profileChildren")?.value,
        profileDwellingid:        this.profileGroup.get("profileDwellingid")?.value,
        profileHasyard:           this.profileGroup.get("profileHasyard")?.value,
        profileLandlordname:      this.profileGroup.get("profileLandlordname")?.value,
        profileLandlordphone:     this.profileGroup.get("profileLandlordphone")?.value,
        profileOtherpetname:      this.profileGroup.get("profileOtherpetname")?.value,
        profileOtherpetbreed:     this.profileGroup.get("profileOtherpetbreed")?.value,
        profileOtherpetsex:       this.profileGroup.get("profileOtherpetsex")?.value,
        profileOtherpetage:       this.otherDogAge,
        profileFamilyallergies:   this.profileGroup.get("profileFamilyallergies")?.value,
        profileResponsiblefordog: this.profileGroup.get("profileResponsiblefordog")?.value,
        profileAdoptionreason:    this.profileGroup.get("profileAdoptionreason")?.value,
        profileDogsleepat:        this.profileGroup.get("profileDogsleepat")?.value,
        profileDogaggresive:      this.profileGroup.get("profileDogaggresive")?.value,
        profileMedfordog:         this.profileGroup.get("profileMedfordog")?.value,
        profileNocaredog:         this.profileGroup.get("profileNocaredog")?.value,
      }

      this.profileSerrvice.createProfile(profile).subscribe(
        (response) => {
          this.router.navigateByUrl('')
        }
      )

    }
    else
    {
      this.displayMessage = "All required fields must be filled!";
    }
    
  }

}
