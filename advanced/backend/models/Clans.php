<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "clans".
 *
 * @property integer $id
 * @property string $name
 * @property string $description
 * @property string $icon
 * @property integer $default_location_id
 */
class Clans extends \yii\db\ActiveRecord
{
    /**
     * @inheritdoc
     */
    public static function tableName()
    {
        return 'clans';
    }

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['name', 'description', 'icon', 'default_location_id'], 'required'],
            [['description'], 'string'],
            [['default_location_id'], 'integer'],
            [['name', 'icon'], 'string', 'max' => 255],
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'description' => 'Description',
            'icon' => 'Icon',
            'default_location_id' => 'Default Location ID',
        ];
    }
}
