import { useState } from "react";
import {
  Container,
  Typography,
  TextField,
  Button,
  Box,
  Grid,
} from "@mui/material";
import profileStyles from "@/app/styles/profile.module.css";
import VerifiedUserIcon from "@mui/icons-material/VerifiedUser";

function profile() {
  var isDisabled = false;
  return (
    <Container maxWidth="sm" className={profileStyles.container}>
      <form className={profileStyles.form}>
        <TextField
          {...(isDisabled ? { disabled: true } : {})}
          id="outlined-disabled"
          label="Ad"
          defaultValue="Murat Can Çelebi"
          variant="filled"
          fullWidth
          autoFocus
          className={profileStyles.formElement}
        />
        <Grid container>
          <Grid item xs={8} className={profileStyles.formElementTwiceInput}>
            <TextField
              {...(isDisabled ? { disabled: true } : {})}
              id="outlined-disabled"
              label="Email"
              defaultValue="muratcelebi@gmail.com"
              variant="filled"
              
            />
          </Grid>
          <Grid item xs={4} className={profileStyles.formElementTwiceButton}>
            <Button
              variant="contained"
              color="success"
              endIcon={<VerifiedUserIcon />}
              size="large"
              
            >
              Doğrula
            </Button>
          </Grid>
        </Grid>
        <TextField
          {...(isDisabled ? { disabled: true } : {})}
          id="filled-disabled"
          label="Şifre"
          defaultValue="***"
          variant="filled"
          fullWidth
          className={profileStyles.formElement}
        />
        <Button
          onClick={(isDisabled = false)}
          variant="contained"
          color="warning"
          className={profileStyles.button}
        >
          Düzenle
        </Button>
      </form>
    </Container>
  );
}

export default profile;
