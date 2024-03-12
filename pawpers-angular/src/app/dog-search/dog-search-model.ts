export interface dogSearchRoot {
    animals:    Animal[]
    //pagination: Pagination;
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
    coat:            null;
    attributes:      Attributes;
    environment:     Environment;
    tags:            string[];
    name:            string;
    description:     string;
    photos:          Photo[];
    videos:          Video[];
    status:          string;
    published_at:    string;
    contact:         Contact;
    _links:          AnimalLinks;
}

export interface AnimalLinks {
    self:         Next;
    type:         Next;
    organization: Next;
}

export interface Next {
    href: string;
}

export interface Attributes {
    spayed_neutered: boolean;
    house_trained:   boolean;
    declawed:        null;
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
    primary:   null;
    secondary: null;
    tertiary:  null;
}

export interface Contact {
    email:   string;
    phone:   string;
    address: Address;
}

export interface Address {
    address1: string;
    address2: string;
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

export interface Pagination {
    count_per_page: number;
    total_count:    number;
    current_page:   number;
    total_pages:    number;
    _links:         PaginationLinks;
}

export interface PaginationLinks {
    previous: Next;
    next:     Next;
}
