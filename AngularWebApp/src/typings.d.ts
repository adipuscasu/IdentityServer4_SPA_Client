// so the typescript compiler doesn't complain about the global config object
declare var config: any;

interface AppConfig {
  baseUrl?: string;
  applicationName?: string;
  emailRegex?: RegExp;
  version?: string;
  apiUrl?: string;
}
interface IApplicationUser {
  name?: string;
  givenName?: string;
  webSite?: string;
  address?: IAddress;
  password?: string;
  userName?: string;
  email?: string;

}
interface IAddress {
  id?: number;
  streetAddress?: string;
  locality?: string;
  postalCode?: string;
  country?: ICountry;
}
interface ICountry {
  id?: number;
  name?: string;
  abbreviation?: string;
}
interface IUser {
  id?: number;
  firstName?: string;
}
