CREATE DATABASE haiden;

CREATE TABLE categories
(
  id_category bigserial NOT NULL,
  name_category text NOT NULL,
  dt_inc_category date
);

ALTER TABLE categories ADD CONSTRAINT id_category
  PRIMARY KEY (id_category);

CREATE TABLE font_links
(
  id_font_link bigserial NOT NULL,
  fkid_font bigint NOT NULL,
  type_link bigint NOT NULL,
  src_font_link text NOT NULL,
  dt_inc_font_linnk date NOT NULL
);

ALTER TABLE font_links ADD CONSTRAINT id_font_link
  PRIMARY KEY (id_font_link);

CREATE TABLE fonts
(
  id_font bigserial NOT NULL,
  name_font text NOT NULL,
  dt_inc_font date NOT NULL
);

ALTER TABLE fonts ADD CONSTRAINT id_font
  PRIMARY KEY (id_font);

CREATE TABLE languages
(
  id_language bigserial NOT NULL,
  name_language text NOT NULL,
  dt_inc_language date NOT NULL
);

ALTER TABLE languages ADD CONSTRAINT id_language
  PRIMARY KEY (id_language);

CREATE TABLE news
(
  id_new bigserial NOT NULL,
  fkid_category bigint NOT NULL,
  fkid_font_link bigint NOT NULL,
  fkid_language bigint NOT NULL,
  received_category text,
  author_new text,
  title_new text NOT NULL,
  src_new text NOT NULL,
  description_new text NOT NULL,
  dt_publication_new date NOT NULL,
  dt_modification_new bigint,
  src_image_new bigint,
  byte_image_new bytea,
  description_image_new text,
  author_image_new text,
  dt_inc_new bigint NOT NULL,
  dt_alt_new bigint
);

ALTER TABLE news ADD CONSTRAINT id_new
  PRIMARY KEY (id_new);

CREATE TABLE stopwords
(
  id_stopword bigserial NOT NULL,
  fkid_language bigint NOT NULL,
  stopword text NOT NULL,
  dt_inc_stopword date NOT NULL,
  unique (stopword, fkid_language)
);

ALTER TABLE stopwords ADD CONSTRAINT id_stopwords
  PRIMARY KEY (id_stopword);

ALTER TABLE font_links ADD CONSTRAINT fk_font_links_font
  FOREIGN KEY (fkid_font) REFERENCES fonts (id_font) ON DELETE RESTRICT;

ALTER TABLE news ADD CONSTRAINT fk_news_
  FOREIGN KEY (fkid_language) REFERENCES languages (id_language) ON DELETE RESTRICT;

ALTER TABLE news ADD CONSTRAINT fk_news_cateogy
  FOREIGN KEY (fkid_category) REFERENCES categories (id_category) ON DELETE RESTRICT;

ALTER TABLE news ADD CONSTRAINT fk_news_font_link
  FOREIGN KEY (fkid_font_link) REFERENCES font_links (id_font_link) ON DELETE RESTRICT;

ALTER TABLE stopwords ADD CONSTRAINT fk_stopwords_
  FOREIGN KEY (fkid_language) REFERENCES languages (id_language) ON DELETE RESTRICT;
