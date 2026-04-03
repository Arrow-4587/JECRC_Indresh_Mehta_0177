import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/authContext';
import { useLanguage } from '../context/languageContext';

const LoginForm = () => {
  const { login, loading } = useAuth();
  const { t } = useLanguage();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    try {
      await login(username, password);
      navigate('/dashboard');
    } catch (err) {
      setError(t('invalidCredentials'));
    }
  };

  return (
    <div className="card login-card">
      <h2>{t('login')}</h2>
      <form className="form-grid" onSubmit={handleSubmit}>
        <div className="form-row">
          <label>{t('username')}:</label>
          <input className="input-field" type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
        </div>
        <div className="form-row">
          <label>{t('password')}:</label>
          <input className="input-field" type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
        </div>
        {error && <p className="error-text">{error}</p>}
        <button className="btn-primary" type="submit" disabled={loading}>
          {loading ? t('loading') : t('login')}
        </button>
      </form>
    </div>
  );
};

export default LoginForm;