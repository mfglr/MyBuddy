import { PostContent } from "./post-content"
import { PostContentError } from "./post-content-eror";


describe("post-content",() => {

  it("should create instance when value is valid", () => {
    const content = new PostContent("Hello World");

    expect(content.value).toBe("Hello World");
  });

  it("should throw postContentError when value is null", () => {
    expect(() => new PostContent(null!)).toThrow(PostContentError);
  })

  it('should throw postContentError when value is undefined', () => {
    expect(() => new PostContent(undefined!))
      .toThrow(PostContentError);
  });

  it('should throw postContentError when value is empty string', () => {
    expect(() => new PostContent(''))
      .toThrow(PostContentError);
  });

  it('should throw postContentError when value is whitespace', () => {
    expect(() => new PostContent('   '))
      .toThrow(PostContentError);
  });

  it('should throw postContentError when value is shorter than min length', () => {
    const tooShort = 'a';

    expect(() => new PostContent(tooShort)).toThrow(PostContentError);
  });

  it('should throw postContentError when value exceeds max length', () => {
    const tooLong = 'a'.repeat(1025);

    expect(() => new PostContent(tooLong)).toThrow(PostContentError);
  });

  it('should allow boundary min length', () => {
    const valid = 'ab';

    const content = new PostContent(valid);

    expect(content.value).toBe(valid);
  });

  it('should allow boundary max length', () => {
    const valid = 'a'.repeat(1024);

    const content = new PostContent(valid);

    expect(content.value).toBe(valid);
  });


});
