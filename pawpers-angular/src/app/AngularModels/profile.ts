import { Favorite } from "./favorite";
import { Reply } from "./reply";
import { Topic } from "./topic";

export interface Main {
    $id:     string;
    $values: Profile[];
}

export interface Profile {
    $id?:                     string;
    profileId?:               number;
    profileName:              string;
    profileStreetaddress:     string;
    profileCity:              string;
    profileStateid?:           number;
    profileZipcode:           string;
    profileAge:               number;
    profileHomephone?:         string;
    profilePersonalphone:     string;
    profileEmail:             string;
    profileOccupation:        string;
    profileSpousename?:        string;
    profileChildren:          number;
    profileDwellingid?:        number;
    profileHasyard:           number;
    profileLandlordname?:      string;
    profileLandlordphone?:     string;
    profileOtherpetname?:      string;
    profileOtherpetbreed?:     string;
    profileOtherpetsex?:       string;
    profileOtherpetage?:       number;
    profileFamilyallergies:   number;
    profileResponsiblefordog: string;
    profileAdoptionreason:    string;
    profileDogsleepat:        string;
    profileDogaggresive:      string;
    profileMedfordog:         string;
    profileNocaredog:         string;
    profileDwelling?:         null;
    profileState?:            null;
    favorites?:               Favorite[];
    replies?:                 Reply[];
    topics?:                  Topic[];
}


