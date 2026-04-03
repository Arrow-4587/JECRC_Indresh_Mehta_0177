import React from 'react';
import LoginForm from '../components/LoginForm';
import { useLanguage } from '../context/languageContext';
import LanguageSelector from '../components/LanguageSelector';
import './Home.css';

const Home = () => {
  const { t } = useLanguage();

  return (
    <div className="page-container">
      <section className="hero-panel">
        <div>
          <h1>{t('welcome')} to {t('home')}</h1>
          <p>Secure single-page auth workflow with dynamic localization built on React Context API.</p>
        </div>
        <LanguageSelector />
      </section>
      <section className="auth-block">
        <LoginForm />
      </section>
    </div>
  );
};

export default Home;