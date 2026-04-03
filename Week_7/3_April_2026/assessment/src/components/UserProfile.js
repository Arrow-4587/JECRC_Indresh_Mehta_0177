import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/authContext';
import { useLanguage } from '../context/languageContext';
import LanguageSelector from './LanguageSelector';

const UserProfile = () => {
  const { user, logout } = useAuth();
  const { t } = useLanguage();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/');
  };

  return (
    <div className="card user-card">
      <h2>{t('userProfile')}</h2>
      <p>{t('welcome')}, <strong>{user?.username || 'Guest'}</strong></p>
      <p><small>{t('authStatus')}: {user ? 'Authenticated' : 'Anonymous'}</small></p>
      <LanguageSelector />
      <button className="btn-primary" onClick={handleLogout}>{t('logout')}</button>
    </div>
  );
};

export default UserProfile;