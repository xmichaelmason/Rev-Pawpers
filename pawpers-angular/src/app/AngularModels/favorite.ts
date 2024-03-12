import { Profile } from "./profile";

export interface Main {
    $id:     string;
    $values: Favorite[];
}

export interface Favorite {
    $id:         string;
    favId:       number;
    dogId:       number;
    isAvailable: number;
    profileId:   number;
    profile:     Profile;
}