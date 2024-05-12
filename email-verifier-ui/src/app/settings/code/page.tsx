import {
  Button,
  TextField,
  Typography,
  Container,
} from '@mui/material';
import LockIcon from '@mui/icons-material/Lock';
import codeStyles from "@/app/styles/code.module.css";

const code = () => {


  const handleSubmit = (e) => {
    e.preventDefault();
    // Kod doğrulama işlemleri burada yapılabilir
  };

  return (
    <Container component="main" maxWidth="xs" className={codeStyles.mainPanel}>
      <div className={codeStyles.iconPanel}><LockIcon color='success' className={codeStyles.icon} /></div>
      <div className={codeStyles.iconPanel}>
        <Typography component="h1" variant="h5">
          Email Doğrulama
        </Typography>
        <Typography component="p">
          ****celebi@gmail.com adresine gönderdiğimiz mail içeriğindeki kodu giriniz.
        </Typography>
        <form>
          <TextField
            variant="outlined"
            margin="normal"
            required
            fullWidth
            id="verificationCode"
            label="Doğrulama Kodu"
            name="verificationCode"
            autoFocus
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="success"
          >
            Doğrula
          </Button>
        </form>
      </div>
    </Container>
  );
};

export default code;