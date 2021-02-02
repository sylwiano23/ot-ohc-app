export class IUserModel {
  aud: string;
  exp: number;
  iss: string;
  nbf: number;
  role: "Administrator" | "User";
  unique_name: string;
}
