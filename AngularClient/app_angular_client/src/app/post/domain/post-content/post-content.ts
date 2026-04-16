import { isNullOrWhiteSpace } from "../../../shared/utils/string-utils";
import { PostContentError } from "./post-content-eror";

export class PostContent{
  private static readonly minLength: number = 2;
  private static readonly maxLength: number = 1024;

  value: string;

  constructor(value:string){
    if (isNullOrWhiteSpace(value))
      throw new PostContentError("Post content cannot be empty!");

    if (value.length < PostContent.minLength || value.length > PostContent.maxLength)
        throw new PostContentError(`Value length must be between ${PostContent.minLength} and ${PostContent.maxLength}.`);

    this.value = value;
  }
}
