import { Button, Grid, Stack, TextField } from "@mui/material";
import { Controller, useForm } from "react-hook-form";
import { useLocation, useNavigate } from "react-router-dom";
import { IUserLoginDto } from "../../app/ApiBase";
import { useAuth } from "../../features/auth";

export function LoginPage() {
  const { signin } = useAuth();
  const navigate = useNavigate();
  const location = useLocation();
  const from = location.state?.from?.pathname || "/";

  const onSubmit = (data: IUserLoginDto) =>
    signin(data, () => {
      console.log("navigate(from, { replace: true })}");
    });

  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      userName: "test@gmail.com",
      password: "string",
    },
  });
  return (
    <Grid container spacing={2} justifyContent="center" alignItems="center">
      <Grid item>
        <Stack
          component="form"
          spacing={2}
          sx={{ width: "300px" }}
          onSubmit={handleSubmit(onSubmit)}
        >
          <Controller
            name="userName"
            control={control}
            rules={{ required: true }}
            render={({ field }) => (
              <TextField
                {...field}
                label="Username"
                helperText={errors.userName && "Incorrect username."}
              />
            )}
          />
          <Controller
            name="password"
            control={control}
            rules={{ required: true }}
            render={({ field }) => (
              <TextField
                {...field}
                type="password"
                label="Password"
                helperText={errors.password && "Password is required."}
              />
            )}
          />
          <Button type="submit" variant="outlined">
            Login
          </Button>
        </Stack>{" "}
      </Grid>
    </Grid>
  );
}
