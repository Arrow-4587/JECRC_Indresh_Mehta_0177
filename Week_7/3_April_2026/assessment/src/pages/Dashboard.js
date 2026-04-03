import React from 'react';
import UserProfile from '../components/UserProfile';
import LanguageSelector from '../components/LanguageSelector';
import { useLanguage } from '../context/languageContext';
import './Dashboard.css';

const Dashboard = () => {
  const { t } = useLanguage();

  return (
    <div className="page-container">
      <header className="dashboard-header">
        <div>
          <h1>{t('dashboard')}</h1>
          <p>Interactive analytics and user insights for your application.</p>
        </div>
        <LanguageSelector />
      </header>

      <section className="dashboard-grid">
        <article className="card metric-card">
          <h3>{t('metrics')}</h3>
          <div className="metric-row"><span>Active Users</span><strong>132</strong></div>
          <div className="metric-row"><span>Signups Today</span><strong>24</strong></div>
          <div className="metric-row"><span>Conversion</span><strong>6.8%</strong></div>
        </article>

        <article className="card activity-card">
          <h3>{t('activity')}</h3>
          <ul>
            <li>User admin logged in</li>
            <li>New account created: jane@company.com</li>
            <li>Password reset requested</li>
            <li>Deployment job completed</li>
          </ul>
        </article>

        <article className="card profile-card">
          <h3>{t('profile')}</h3>
          <UserProfile />
        </article>
      </section>
    </div>
  );
};

export default Dashboard;