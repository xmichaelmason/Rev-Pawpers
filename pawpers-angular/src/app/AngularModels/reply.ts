import { Profile } from "./profile";
import { Topic } from "./topic";

export interface Main {
    $id:     string;
    $values: Reply[];
}

export interface Reply {
    element?: any;
    $id?:            string;
    replyId?:        number;
    replyMessage:   string;
    replyTimestamp?: Date;
    profileId?:      number;
    topicId?:        number;
    profile?:        Profile;
    topic?:          Topic;
    show?:          boolean;
}
