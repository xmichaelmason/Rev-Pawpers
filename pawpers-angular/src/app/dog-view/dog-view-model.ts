export interface dogViewRoot {
    animal: Animal;
}

export interface Animal {
    id:              number;
    organization_id: string;
    url:             string;
    type:            string;
    species:         string;
    breeds:          Breeds;
    colors:          Colors;
    age:             string;
    gender:          string;
    size:            string;
    coat:            string;
    name:            string;
    description:     string;
    photos:          Photo[];
    videos:          Video[];
    status:          string;
    attributes:      Attributes;
    environment:     Environment;
    tags:            string[];
    contact:         Contact;
    published_at:    string;
    distance:        null;
    _links:          Links;
}

export interface Links {
    self:         Organization;
    type:         Organization;
    organization: Organization;
}

export interface Organization {
    href: string;
}

export interface Attributes {
    spayed_neutered: boolean;
    house_trained:   boolean;
    declawed:        boolean;
    special_needs:   boolean;
    shots_current:   boolean;
}

export interface Breeds {
    primary:   string;
    secondary: null;
    mixed:     boolean;
    unknown:   boolean;
}

export interface Colors {
    primary:   string;
    secondary: null;
    tertiary:  null;
}

export interface Contact {
    email:   string;
    phone:   string;
    address: Address;
}

export interface Address {
    address1: null;
    address2: null;
    city:     string;
    state:    string;
    postcode: string;
    country:  string;
}

export interface Environment {
    children: boolean;
    dogs:     boolean;
    cats:     boolean;
}

export interface Photo {
    small:  string;
    medium: string;
    large:  string;
    full:   string;
}

export interface Video {
    embed: string;
}
