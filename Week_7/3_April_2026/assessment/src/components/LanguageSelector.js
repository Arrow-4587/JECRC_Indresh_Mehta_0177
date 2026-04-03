import React from 'react';
import { useLanguage } from '../context/languageContext';

const LanguageSelector = () => {
  const { language, changeLanguage, t } = useLanguage();

  return (
    <div className="language-selector">
      <label>{t('language')}:</label>
      <select value={language} onChange={(e) => changeLanguage(e.target.value)}>
        <option value="en">{t('english')}</option>
        <option value="es">{t('spanish')}</option>
        <option value="fr">{t('french')}</option>
        <option value="de">{t('german')}</option>
      </select>
    </div>
  );
};

export default LanguageSelector;