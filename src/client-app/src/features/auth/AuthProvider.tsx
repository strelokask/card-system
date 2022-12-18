import { createContext, useContext, useState } from "react";
import { apiClient } from "../../app/api";
import {
  IUserLoginDto,
  IUserLoginResponse,
  UserLoginDto,
} from "../../app/ApiBase";

interface AuthContextType {
  user: any;
  signin: (user: IUserLoginDto, callback: VoidFunction) => void;
  signout: (callback: VoidFunction) => void;
}

export const AuthContext = createContext<AuthContextType>(null!);

export function useAuth() {
  return useContext(AuthContext);
}

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [user, setUser] = useState<IUserLoginResponse>(null!);

  const signin = async (dto: IUserLoginDto, callback: VoidFunction) => {
    const userData = await apiClient.login(new UserLoginDto(dto));
    console.log("user data", userData);
    setUser(userData);
    return callback();
  };

  const signout = (callback: VoidFunction) => {
    // return fakeAuthProvider.signout(() => {
    //   setUser(null);
    //   callback();
    // });
    return null;
  };

  const value = { user, signin, signout };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}
