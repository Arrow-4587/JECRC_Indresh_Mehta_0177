import React, { createContext, useState, useContext } from 'react';

const LanguageContext = createContext();

export const useLanguage = () => {
  const context = useContext(LanguageContext);
  if (!context) {
    throw new Error('useLanguage must be used within LanguageProvider');
  }
  return context;
};

const translations = {
  en: {
    welcome: 'Welcome',
    logout: 'Logout',
    userProfile: 'User Profile',
    home: 'Home',
    dashboard: 'Dashboard',
    login: 'Login',
    overview: 'Overview',
    metrics: 'Key Metrics',
    activity: 'Recent Activity',
    quickActions: 'Quick Actions',
    profile: 'Profile',
    authStatus: 'Auth Status',
    username: 'Username',
    password: 'Password',
    submit: 'Submit',
    invalidCredentials: 'Invalid credentials',
    loading: 'Loading...',
    language: 'Language',
    english: 'English',
    spanish: 'Spanish',
    french: 'French',
    german: 'German'
  },
  es: {
    welcome: 'Bienvenido',
    logout: 'Cerrar sesión',
    userProfile: 'Perfil de usuario',
    home: 'Inicio',
    dashboard: 'Panel',
    login: 'Iniciar sesión',
    overview: 'Resumen',
    metrics: 'Métricas clave',
    activity: 'Actividad reciente',
    quickActions: 'Acciones rápidas',
    profile: 'Perfil',
    authStatus: 'Estado de autenticación',
    username: 'Nombre de usuario',
    password: 'Contraseña',
    submit: 'Enviar',
    invalidCredentials: 'Credenciales inválidas',
    loading: 'Cargando...',
    language: 'Idioma',
    english: 'Inglés',
    spanish: 'Español',
    french: 'Francés',
    german: 'Alemán'
  },
  fr: {
    welcome: 'Bienvenue',
    logout: 'Se déconnecter',
    userProfile: 'Profil utilisateur',
    home: 'Accueil',
    dashboard: 'Tableau de bord',
    login: 'Connexion',
    overview: 'Vue d’ensemble',
    metrics: 'Indicateurs clés',
    activity: 'Activité récente',
    quickActions: 'Actions rapides',
    profile: 'Profil',
    authStatus: 'État',
    username: 'Nom d’utilisateur',
    password: 'Mot de passe',
    submit: 'Envoyer',
    invalidCredentials: 'Identifiants invalides',
    loading: 'Chargement...',
    language: 'Langue',
    english: 'Anglais',
    spanish: 'Espagnol',
    french: 'Français',
    german: 'Allemand'
  },
  de: {
    welcome: 'Willkommen',
    logout: 'Abmelden',
    userProfile: 'Benutzerprofil',
    home: 'Startseite',
    dashboard: 'Dashboard',
    login: 'Anmelden',
    overview: 'Überblick',
    metrics: 'Kernmetriken',
    activity: 'Aktuelle Aktivität',
    quickActions: 'Schnellaktionen',
    profile: 'Profil',
    authStatus: 'Authentifizierungsstatus',
    username: 'Benutzername',
    password: 'Passwort',
    submit: 'Senden',
    invalidCredentials: 'Ungültige Anmeldedaten',
    loading: 'Wird geladen...',
    language: 'Sprache',
    english: 'Englisch',
    spanish: 'Spanisch',
    french: 'Französisch',
    german: 'Deutsch'
  }
};

export const LanguageProvider = ({ children }) => {
  const [language, setLanguage] = useState('en');

  const changeLanguage = (lang) => setLanguage(lang);
  const t = (key) => translations[language][key] || key;

  return (
    <LanguageContext.Provider value={{ language, changeLanguage, t }}>
      {children}
    </LanguageContext.Provider>
  );
};