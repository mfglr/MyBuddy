import { Media } from "../../media-core/media";
import { PostContent } from "./post-content";

export interface Post{
  id: string;
  createdAt: Date;
  updatedAt?: Date;
  content?: PostContent;
  media: Array<Media>;
  userId: string;
  name?: string;
  userName: string;
  userMedia?: Media;
}
