import { Media } from "../../media-core/media";
import { CommentContent } from "./comment-content";

export interface Comment{
  id: string,
  createdAt : Date,
  updatedAt?: Date,
  postId: string,
  parentId?: string,
  repliedId?: string,
  content: CommentContent,
  likeCount: number,
  childCount: number;
  userId: string,
  userName: string,
  name?: string,
  userMedia?: Media,
}
